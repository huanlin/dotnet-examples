Note

- Web.config 裡面同時包含了兩種層級的錯誤攔截設定：ASP.NET 應用程式層級與 IIS 層級。
- 在 Global.asax 的 Application_Error 方法中設定當前執行緒的 CurrentUICulture，應該就能在 ASP.NET 應用程式層級的錯誤處理頁面中取得該設定。
