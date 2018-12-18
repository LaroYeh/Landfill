using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest.LearnWithTry
{
    class BuildTree
    {
        //透過紀錄ParentId為何，然後在次整理時將Child放入

        public BuildTree()
        {
            //假資料
            List<LandMenuDto> menus = new List<LandMenuDto>
            {
                new LandMenuDto { Id = 1, Name = "Landfill", ParentId = null },
                new LandMenuDto { Id = 2, Name = "Land01", ParentId = 1 },
                new LandMenuDto { Id = 3, Name = "Land02", ParentId = 1 },
                new LandMenuDto { Id = 4, Name = "Land03", ParentId = 1 },
                new LandMenuDto { Id = 5, Name = "Land04", ParentId = 1 },
                new LandMenuDto { Id = 6, Name = "Land05", ParentId = 1 },
                new LandMenuDto { Id = 7, Name = "Land05.Sub", ParentId = 6 },
            };
            List<PermissionDto> permissions = new List<PermissionDto>
            {
                new PermissionDto { Id = 1, Name="DemoAuthA"},
                new PermissionDto { Id = 2, Name="DemoAuthB"},
                new PermissionDto { Id = 3, Name="Index"},
                new PermissionDto { Id = 4, Name="AuditLog.C"},
                new PermissionDto { Id = 5, Name="AuditLog.R"},
                new PermissionDto { Id = 6, Name="AuditLog.U"},
                new PermissionDto { Id = 7, Name="AuditLog.D"},
            };

            List<MenuRelatePermissionDto> mp = new List<MenuRelatePermissionDto>
            {
                new MenuRelatePermissionDto{MenuId = 1, PermissionId = 1},
                new MenuRelatePermissionDto{MenuId = 1, PermissionId = 2},
                new MenuRelatePermissionDto{MenuId = 2, PermissionId = 3},
                new MenuRelatePermissionDto{MenuId = 4, PermissionId = 4},
                new MenuRelatePermissionDto{MenuId = 4, PermissionId = 5},
                new MenuRelatePermissionDto{MenuId = 4, PermissionId = 6},
                new MenuRelatePermissionDto{MenuId = 4, PermissionId = 7},
                new MenuRelatePermissionDto{MenuId = 6, PermissionId = 1},
                new MenuRelatePermissionDto{MenuId = 7, PermissionId = 2},
            };

            //下中斷點到裡面看結果
            TreeSample(menus, mp, permissions); 
        }
        public class LandMenuDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? ParentId { get; set; }
            public List<LandMenuDto> ChildMenu { get; set; }
            public List<PermissionDto> RelatePermission { get; set; }
            public LandMenuDto()
            {
                ChildMenu = new List<LandMenuDto>();
                RelatePermission = new List<PermissionDto>();
            }
        }
        public class PermissionDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class MenuRelatePermissionDto
        {
            //public int Id { get; set; }
            public int MenuId { get; set; }
            public int PermissionId { get; set; }
        }

        /// <summary>
        /// 用假資料產生樹狀結構 (用中斷點直接看)
        /// </summary>
        public void TreeSample(List<LandMenuDto> menus, List<MenuRelatePermissionDto> mp, List<PermissionDto> permissions)
        {
 
            foreach (var menu in menus)
            {
                List<LandMenuDto> children = GetChildMenu(menu.Id, menus).ToList();
                List<PermissionDto> permissionlist = GetRelatePermission(menu.Id, mp, permissions).ToList();
                if (children.Any())
                {
                    menu.ChildMenu.AddRange(children);
                }
                if (permissionlist.Any())
                {
                    menu.RelatePermission.AddRange(permissionlist);
                }
            }

        }

        //參考
        //https://codereview.stackexchange.com/questions/163957/building-a-tree-from-a-flat-listnodes
        private IEnumerable<LandMenuDto> GetChildMenu(int Id, List<LandMenuDto> source)
        {
            var items = source.Where(n => n.ParentId == Id);
            return items;
        }
        private IEnumerable<PermissionDto> GetRelatePermission(int MenuId, List<MenuRelatePermissionDto> relate, List<PermissionDto> source)
        {
            var Permissionlist = relate.Where(n => n.MenuId == MenuId).Select(n => n.PermissionId);
            var items = source.Where(n => Permissionlist.Contains(n.Id));
            return items;
        }
    }
}