document.addEventListener('DOMContentLoaded', function () {
    var checkbox = document.getElementById('isAdminCheckbox');
    // var form = document.getElementById('registerForm');
    function updateBodyClass() {
        if (checkbox.checked) {
            document.body.classList.add('IsAdmin');
        } else {
            document.body.classList.remove('IsAdmin');
        }
    }
    checkbox.addEventListener('change', updateBodyClass);
    updateBodyClass(); // Set initial state
});