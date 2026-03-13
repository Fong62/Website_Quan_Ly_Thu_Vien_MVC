# Website Quản Lý Thư Viện (ASP.NET Core MVC)

## 📖 Tổng quan
**Website Quản Lý Thư Viện** là một ứng dụng web được xây dựng dựa trên kiến trúc MVC, thiết kế để hỗ trợ việc quản lý sách, độc giả và tự động hóa các quy trình mượn/trả sách. Hệ thống giúp số hóa các hoạt động của thư viện, mang lại trải nghiệm tra cứu và mượn sách tiện lợi cho độc giả, đồng thời giúp thủ thư quản lý kho sách một cách tối ưu.

## 🚀 Các tính năng chính
* **Quản lý kho sách:** Thêm mới, chỉnh sửa, xóa và tổ chức thông tin sách theo danh mục, tác giả, nhà xuất bản.
* **Quản lý Mượn/Trả:** Theo dõi chi tiết các phiếu mượn sách, tình trạng sách, ngày đến hạn và lịch sử mượn của từng độc giả.
* **Tra cứu thông minh:** Hỗ trợ tìm kiếm sách nhanh chóng theo phân loại sách.
* **Phân quyền người dùng:** Hệ thống xác thực và phân quyền chặt chẽ sử dụng **ASP.NET Core Identity** (Quản trị viên/Độc giả).

## 🛠️ Công nghệ sử dụng
* **Backend:** ASP.NET Core MVC, Entity Framework Core.
* **Cơ sở dữ liệu:** SQL Server.
* **Xác thực:** ASP.NET Core Identity.
* **Frontend:** HTML5, CSS3, JavaScript, Bootstrap.

## ⚙️ Hướng dẫn cài đặt

### Yêu cầu hệ thống
* [.NET SDK 8](https://dotnet.microsoft.com/download).
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
* Visual Studio 2022.

### Các bước cài đặt
1.  **Clone dự án**
    ```bash
    git clone [https://github.com/Fong62/Website_Quan_Ly_Thu_Vien_MVC.git](https://github.com/Fong62/Website_Quan_Ly_Thu_Vien_MVC.git)
    cd Website_Quan_Ly_Thu_Vien_MVC
    ```

2.  **Cấu hình Cơ sở dữ liệu**
    * Mở tệp `appsettings.json`, tìm và cập nhật chuỗi kết nối `DefaultString` sao cho phù hợp với SQL Server trên máy của bạn.
    * Mở Terminal/Package Manager Console và chạy lệnh sau để tạo database:
        ```bash
        dotnet ef database update
        ```

3.  **Chạy ứng dụng**
    ```bash
    dotnet run
    ```
    Truy cập vào đường dẫn hiển thị trên terminal để bắt đầu sử dụng hoặc mở dự án trên Visual Studio và chạy.

### 4. 🔐 Hướng dẫn Đăng nhập & Trải nghiệm

Hệ thống hiện tại không cung cấp sẵn các tài khoản mẫu định sẵn. 

Để trải nghiệm hệ thống, vui lòng truy cập vào trang chủ của ứng dụng, nhấp vào nút **Đăng ký (Register)** để tự tạo cho mình một tài khoản mới. Sau khi đăng ký thành công, bạn có thể đăng nhập và sử dụng các tính năng của trang web.

## 📂 Cấu trúc thư mục
```text
Website_Quan_Ly_Thu_Vien_MVC
├── Controllers       # Xử lý luồng dữ liệu & Điều hướng người dùng
├── Models            # Các lớp Entity & ViewModels đại diện cho dữ liệu
├── Data              # Cấu hình DbContext & Migrations
├── Views             # Giao diện người dùng (Razor Views)
├── wwwroot           # Chứa các tệp tĩnh (CSS, JS, Images)
└── appsettings.json  # Cấu hình hệ thống (Chứa chuỗi kết nối Database)
