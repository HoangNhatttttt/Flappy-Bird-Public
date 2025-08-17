/*
!Làm cái này mục đích thử nghiệm. Chưa kiểm chứng tính thực tiễn, có thể sửa đổi hoặc bỏ.

* Thông tin cơ bản
Bao gồm DebugManager (GameObject) ; DebugPanelUI (Canvas) ; IDebugPanel (Interface Class) ; Script DebugPanel

DebugManager:
- Chứa script DebugManager.cs: Là script chính lo các chức hiển thị panel debug
- Các Script DebugPanel nhét hết vào đây, sử dụng Interface IDebugPanel

DebugPanelUI:
- Chứa text để hiển thị cho từng DebugPanel

IDebugPanel:
- Class Interface làm khuôn mẫu cho các script Debug Panel

Script DebugPanel:
- Tạo từ Class Interface IDebugPanel, cần hiển thị thông tin gì thì viết vào đây
- Chứa public variable Text và Class cần Debug, có thể tạo nhiều Text nếu cần thiết

* Cách sử dụng
1. Tạo GameObject DebugManager, nhét DebugManager.cs vào đây, nhét thêm các scipt DebugPanel vào đây
2. Tạo Canvas DebugPanelUI, nhét các Text hiển thị debug vào trong đây
3. Nhét GameObject Class cần debug và Text hiển thị debug vào script DebugPanel thuộc GameObject DebugManager
4. Chỉnh lại keybind cho từ Text hiển thị debug trong hàm Update() thuộc DebugManager.cs
*/