// FormSubmitButton
document.getElementById("submit-btn").addEventListener("click", function (event) {
    // Lấy tất cả các input fields
    const inputFields = document.querySelectorAll(".input-container input");
    let formIsValid = true; // Biến để kiểm tra tính hợp lệ tổng thể

    // Duyệt qua từng input field để kiểm tra
    inputFields.forEach(function (inputField) {
        const errorMessage = inputField.nextElementSibling; // Lấy thẻ span (error-message) kế tiếp
        if (inputField.value.trim() === "") {
            errorMessage.style.visibility = "visible";
            errorMessage.style.display = "block"; // Hiển thị thông báo lỗi
            inputField.style.borderColor = "#B02424"; // Đổi màu border thành đỏ
            formIsValid = false; // Form không hợp lệ
        } else {
            errorMessage.style.visibility = "hidden";
            errorMessage.style.display = "none"; // Ẩn thông báo lỗi
            inputField.style.borderColor = ""; // Reset lại border nếu hợp lệ
        }
    });

    // Ngăn form submit nếu có input không hợp lệ
    if (!formIsValid) {
        event.preventDefault();
    }
});

