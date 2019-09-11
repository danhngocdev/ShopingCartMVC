var WishList = {
    init: function () {
        WishList.regEvents();
    },
    regEvents: function () {
        $('#wishlist').off('click').on('click', function () {
            debugger;
            $.ajax({
                url: '/Home/Create',
                data: { ProductID: $(this).data('id')},
                dataType: 'json',
                type: 'POST',
                success: (res) => {
                    if (res.status == true) {
                        window.location.href = "/Home";
                    } else {
                        window.location.href = "/Login";
                    }
                }
            })
        });
    }
      
    
    }

WishList.init();