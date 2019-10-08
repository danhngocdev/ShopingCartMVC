var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listproduct = $('.quantity');
            var cartList = [];
            $.each(listproduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        Id: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: (res) => {
                    if (res.status == true) {
                        Swal.fire({
                            position: 'bot-end',
                            type: 'success',
                            title: 'Cập Nhập Giỏ Hàng Thành Công',
                            showConfirmButton: false,
                            timer: 1500
                        })
                        window.location.href = "/Cart";
                       
                    }
                }
            })
        });

        $('#Addtocart').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/AddItem',
                data: { productID: $(this).data('id'), quantity:1 },
                datatype: 'json',
                type: 'POST',
                success: (res) => {
                    if (res.status) {
                        Swal.fire({
                            position: 'bot-end',
                            type: 'success',
                            title: 'Thêm Sản Phẩm Thành Công',
                            showConfirmButton: false,
                            timer: 1500
                        });
                        //$('#123').load(location.href + "#123");
                    }
                }

            })
        })

        $('#btnDelete').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: (res) => {
                    if (res.status) {
                        Swal.fire({
                            position: 'bot-end',
                            type: 'success',
                            title: 'Xóa Giỏ Hàng Thành Công',
                            showConfirmButton: false,
                            timer: 1500
                        })
                        window.location.href = "/Cart";
                    }
                   }
            })
        });
  
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: (res) => {
                    if (res.status == true) {
                        window.location.href = "/";
                    }
                }
            })
        });

        $('.btn-delete1').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: (res) => {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })
        });
    }

}
cart.init();