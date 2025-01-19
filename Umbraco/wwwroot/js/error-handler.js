const ErrorHandler = {
    modal: null,

    init: function () {
        this.modal = new bootstrap.Modal(document.getElementById('errorModal'));
        this.setupAjaxErrorHandling();
        this.setupGlobalErrorHandling();
    },

    show: function (title, message, details = null, showRetry = false) {
        document.getElementById('errorTitle').textContent = title;
        document.getElementById('errorMessage').textContent = message;

        const detailsElement = document.getElementById('errorDetails');
        if (details) {
            detailsElement.textContent = details;
            detailsElement.style.display = 'block';
        } else {
            detailsElement.style.display = 'none';
        }

        document.getElementById('errorRetryBtn').style.display = showRetry ? 'block' : 'none';
        this.modal.show();
    },

    setupAjaxErrorHandling: function () {
        $(document).ajaxError((event, xhr, settings) => {
            let message = 'An error occurred while processing your request.';
            let details = null;

            try {
                const response = JSON.parse(xhr.responseText);
                message = response.message || message;
                details = response.details;
            } catch (e) {
                console.error('Error parsing error response:', e);
            }

            this.show('Error', message, details, true);
        });
    },

    setupGlobalErrorHandling: function () {
        window.onerror = (msg, url, lineNo, columnNo, error) => {
            this.show(
                'JavaScript Error',
                msg,
                `Location: ${url}\nLine: ${lineNo}\nColumn: ${columnNo}`
            );
            return false;
        };
    }
};
