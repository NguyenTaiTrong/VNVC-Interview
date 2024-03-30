Hướng dẫn chạy run app:
1. Tạo database sql server với tên: Test25032024
2. run cmd: dotnet ef database update trong path: ..\winform-test-27032024\Server
3. run script đê generate ra data và procedure trong thư mục: ...\winform-test-27032024\Server\ScriptsSQL
4. dotnet run --urls=https://localhost:7266 (vì hiện tại chưa setup domain trong env nên bắt buộc chạy port này)
5. Access client folder: dotnet run
6. Tiến hành test
Account access: 
- 1234567890
- 9876543210
- 5551234567


Triển khai monitoring

Hãy thiết lập hệ thống monitoring cơ bản đo lường số lượng người dùng sử dụng app xổ số.
-> Điều này có thể config và check số lượng access request trên NGINX

[Câu hỏi chỉ cần trả lời lý thuyết, không cần code] - nếu bạn phải monitor performance của ứng dụng xổ số, bạn sẽ track những metrics gì?
- Tài nguyên hệ thống sử dụng: Theo dõi việc sử dụng tài nguyên hệ thống như CPU, bộ nhớ và băng thông mạng. Điều này giúp định vị các vấn đề hiệu suất và kế hoạch mở rộng.

- Thời gian downtime: Đo thời gian mà ứng dụng không hoạt động hoặc không thể truy cập được. Điều này giúp đánh giá độ tin cậy của hệ thống và hiệu suất của các biện pháp phục hồi.

- Tỷ lệ lỗi: Đo tỷ lệ các yêu cầu gặp lỗi so với tổng số yêu cầu. Tỷ lệ lỗi cao có thể là dấu hiệu của các vấn đề kỹ thuật hoặc hiện tượng không mong muốn.

- Số lượng người dùng đồng thời (Concurrent Users): Đo số lượng người dùng đồng thời kết nối và sử dụng ứng dụng. Điều này giúp đảm bảo rằng hệ thống có thể xử lý tải lớn từ nhiều người dùng cùng một lúc.

- Thời gian phản hồi: Đo thời gian mà ứng dụng mất để phản hồi lại các yêu cầu từ người dùng. Thời gian phản hồi ngắn là một chỉ số quan trọng để đảm bảo sự hài lòng của người dùng.



