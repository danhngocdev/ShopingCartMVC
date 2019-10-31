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
        
        $('.Addtocart').off('click').on('click', function () {
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
                        $('.shopping-cart').load('/Home/Index .shopping-cart');
                        //window.location.href = "/";
                    } 
                }

            })
        })
        $(document).ready(function () {
            $('.AddToCartTest').click(function () {
                debugger
                var Pqty = $(this).closest("form").find(".qty").val();
                var ProductID = $(this).closest("form").find(".pId").text();
                AddtoCart(ProductID, Pqty);
            });
        });
        function AddtoCart(pid, qty) {
            debugger;
            if (qty <= 0) {
                Swal.fire({
                    type: 'error',
                    text: 'Số Lượng Sản Phẩm Phải Lớn Hơn 1 Hoặc Bằng 1!',
                })
            } else {
                $.ajax({
                    url: '/Cart/AddItem',
                    data: { productID: pid, quantity: qty },
                    datatype: 'json',
                    type: 'POST',
                    success: (res) => {
                        if (res.status) {
                            window.location.href = "/Cart";
                        } else {
                            Swal.fire({
                                type: 'error',
                                title: 'Thất Bại',
                                text: 'Vui Lòng Thử Lại!', s
                            })
                        }

                    }
                })
            }
            
        }
        //$('#AddToCartTest').off('click').on('click', function () {
        //    debugger;
        //    $.ajax({
        //        url: '/Cart/AddItem',
        //        data: { productID: $(this).data('id'), quantity: $(this).data('.quantity').val() },
        //        datatype: 'json',
        //        type: 'POST',
        //        success: (res) => {
        //            if (res.status) {
        //                Swal.fire({
        //                    position: 'bot-end',
        //                    type: 'success',
        //                    title: 'Thêm Sản Phẩm Thành Công',
        //                    showConfirmButton: false,
        //                    timer: 1500
        //                });
        //                //$('#123').load(location.href + "#123");
        //                $('.shopping-cart').load('/Home/Index .shopping-cart');
        //                //window.location.href = "/";
        //            }
        //        }

        //    //})
        //})
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
   