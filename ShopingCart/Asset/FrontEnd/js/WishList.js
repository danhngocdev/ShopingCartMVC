var WishList = {
    init: function () {
        WishList.regEvents();
    },
    $('.pe-7s-like').off('click').on('click', function () {
            var listproduct = $('.quantity');
            var list = [];
            $.each(listproduct, function (i, item) {
                list.push({
                    Quantity: $(item).val(),
                    Product: {
                        Id: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/Create',
                data: { listp: JSON.stringify(list) },
                dataType: 'json',
                type: 'POST',
                success: (res) => {
                    if (res.status == true) {
                        window.location.href = "/";
                    }
                }
            })
        });
    
    }

}
WishList.init();