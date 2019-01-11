# PLURK

## 註冊一個APP

寫這篇時，是使用 Plurk API 2.0 https://www.plurk.com/API



###註冊資料

| 作者:           | warakia                                                      |
| --------------- | ------------------------------------------------------------ |
| 類別:           | (選一個)第三方網站登入帳號整合 手機或桌面應用程式 機器人或資料擷取/蒐集(crawler) |
| 名稱:           | * 不允許使用特殊字元，例如：@, %, *, #...（可使用中文及空白字元）(必須在plurk上獨一無二) |
| 服務圖示:       |                                                              |
| 開發公司/個人:  |                                                              |
| 官方網站:       | (必填)                                                       |
| OAuth callback: | * 如果這不是一個網頁應用程式，請留空白即可                   |
| 應用服務說明:   |                                                              |

送出後，如果沒問題就成功了，以後能透過

https://www.plurk.com/PlurkApp 來管理自己的App

## 測試工具設定

※接下來的資訊都請妥善保管，不然別人就能用你的名義做壞事

可以輸入網址來測試 https://www.plurk.com/OAuth/test/

或者是在PlurkApp管理畫面點「測試工具」

進來後，會發現Token和Sercet是空的，就記得依序

1. 點Get Request Token
2. 點Open Authorization URL並允許請求，還有記下一組授權碼
3. 點Get Access Token，然後輸入剛才的授權碼

如果不點的話，會出現不允許操作(驗證不過: 40106:invalid access token)

## 試用Api

說明：www.plurk.com/API

使用前，最好先閱讀 Plurk data 和 User data 
這邊有定義下面要用的參數說明，可以減少嘗試

### /App/Timeline/getPlurk

以這個API為例，其實就是輸入每個噗的Id就行了，只是要Encrypt base-36 (API文件上有說明)

EX: n4f2n7 => 1398143779

就能收到資料