var contact = {
    innit: function () {
        contact.registerEvent();
    },
    registerEvent: () => {
        $('#btnSend').off('click').on('click', () => {
            var name = $('#name').val();
            var email = $('#email').val();
            var phone = $('#phone').val();
            var message = $('#message').val();

            $.ajax({
                url: '/Contact/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    email: email,
                    phone: phone,
                    message: message
                    
                },
                success: (res) => {
                    if (res.status == true) {
                        alert('Gửi Thành Công');
                        contact.resetFrom();
                    }
                }
            })
        });
    },
    resetFrom: () => {
         $('#name').val('');
         $('#email').val('');
        $('#phone').val('');
       $('#message').val('')
    }
}
contact.innit();