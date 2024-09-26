
 function showError(input, message) {
     const errorSpan = input.parentElement.querySelector('.form-input-error');
     errorSpan.textContent = message;
     errorSpan.style.display = 'block'; 
 }


 function hideError(input) {
     const errorSpan = input.parentElement.querySelector('.form-input-error');
     errorSpan.style.display = 'none'; 
 }

function toggleMenu() {
    var menu = document.querySelector('.main-menu');
    menu.classList.toggle('show');

    var isExpanded = menu.classList.contains('show');
    document.querySelector('.btn-menu').setAttribute('aria-expanded', isExpanded);
}

