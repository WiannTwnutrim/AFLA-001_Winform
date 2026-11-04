# AFLA-001

## SQLite 資料庫與 GitHub

- `AFLA-001/ALFA001.db`：Git 追蹤的資料庫，也是 Debug 開發執行時讀寫的唯一資料來源。
- `AFLA-001/bin/Debug/net8.0-windows/ALFA001.db`：由 csproj 的 `CopyToOutputDirectory=PreserveNewest` 在建置時產生的副本。bin 被 Git 忽略，開發時不再讀寫此副本。
- Release 或獨立部署時，使用執行檔旁的 `ALFA001.db`。部署後的資料不會自動回傳到開發專案。

原本程式使用 `AppContext.BaseDirectory`，因此開發時修改的是 bin 副本；建置僅會從專案複製到 bin，不會反向同步，所以 GitHub 看不到執行期間的資料更新。

現在 Debug 執行時會往上尋找 `AFLA-001.csproj`，直接使用專案資料庫；找不到專案時則使用執行檔旁的 DB。不存在的 DB 會報錯，避免 SQLite 自動建立空白檔案。

更新 GitHub 前，先關閉程式以完成資料庫寫入。在 Visual Studio 的 Git 變更中，將 `AFLA-001/ALFA001.db` 與程式碼一起暫存、提交並推送。Git push 只推送已提交內容，不會自動加入尚未提交的資料。

命令列範例：

```powershell
git add AFLA-001/ALFA001.db AFLA-001/Sqllite.cs README.md .gitignore
git commit -m "Update application and SQLite database"
git push
```

SQLite 的 `-wal`、`-shm`、`-journal` 是執行時暫存檔，不提交。資料庫是二進位檔，多人同時修改時需選定一份正確版本，無法像程式碼逐行合併。