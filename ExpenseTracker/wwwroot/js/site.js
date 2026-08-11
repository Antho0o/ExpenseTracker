// ExpenseTracker site JavaScript

document.addEventListener("DOMContentLoaded", function () {

    const forms = document.querySelectorAll("form");

    forms.forEach(function (form) {

        form.addEventListener("submit", function () {

            const submitButton =
                form.querySelector(
                    'button[type="submit"]'
                );

            if (!submitButton) {
                return;
            }

            if (form.checkValidity()) {

                submitButton.disabled = true;

            }

        });

    });

});