var WishList = {
    init: function () {
        WishList.regEvents();
    },
	regEvents: function () {
		$(document).on('click', '#wishlist', function () {
				debugger 
			var len = $("#wishlist").length;
			$.ajax({
				url: '/Home/Create',
				data: { ProductID: $(this).data('id') },
				dataType: 'json',
				type: 'POST',
				success: (res) => {
					if (res.status == true) {
						debugger
						$('#product-wrapper').load('https://localhost:44347/Home/Index' + '#product-action');
						//window.location.href = "/Home";tab - content
					} else {
						window.location.href = "/Login";
					}
				}
			});
			}
		);
		$(document).on('click', '#wishlistDisLike', function () {
	        $.ajax({
				url: '/WishList/Remove',
		        data: { ProductID: $(this).data('id') },
		        dataType: 'json',
		        type: 'POST',
				success: (res) => {
			        if (res.status == true) {
				        //window.location.href = "/Home";tab - content
				        $('#tab-content').load('/Home');
			        } else {
				        //window.location.href = "/Login";
			        }
		        }
	        })
		});
    }
    }

WishList.init();