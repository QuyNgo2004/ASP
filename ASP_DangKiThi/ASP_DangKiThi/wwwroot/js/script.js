function openModal(url) {
    $.ajax({
        url: url, // Địa chỉ URL để lấy nội dung modal
        type: 'GET',
        success: function (response) {
            $('#modalBody').html(response); // Đặt nội dung vào modal
            $('#myModal').modal('show'); // Mở modal
        },
        error: function () {
            alert('Error occurred while fetching data.');
        }
    });
}