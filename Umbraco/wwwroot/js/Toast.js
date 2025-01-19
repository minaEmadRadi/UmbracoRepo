const ToastNotification = {
    toast: null,

    init: function () {
        this.toast = new bootstrap.Toast(document.getElementById('errorToast'), {
            delay: 5000,
            autohide: true
        });
    },

    show: function (message, title = 'Error') {
        document.getElementById('toastTitle').textContent = title;
        document.getElementById('toastMessage').textContent = message;
        this.toast.show();
    }
};

$(document).ready(function () {
    ToastNotification.init();
});