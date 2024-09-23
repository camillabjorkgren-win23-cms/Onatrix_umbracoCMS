
 function handleContactFormSubmit(event) {
     event.preventDefault(); 

     const name = document.getElementById('name');
     const email = document.getElementById('email');
     const message = document.getElementById('message');

     let isValid = true; 

  
     if (name.value.trim() === '') {
         showError(name, 'You must enter your name');
         isValid = false;
     } else {
         hideError(name);
     }


     if (!email.validity.valid) {
         showError(email, 'You must enter a valid email');
         isValid = false;
     } else {
         hideError(email);
     }

 
     if (message.value.trim() === '') {
         showError(message, 'You must enter a question');
         isValid = false;
     } else {
         hideError(message);
     }


     if (isValid) {
         console.log('Form is valid, submit the form');
     }
 }


 function showError(input, message) {
     const errorSpan = input.parentElement.querySelector('.form-input-error');
     errorSpan.textContent = message;
     errorSpan.style.display = 'block'; 
 }


 function hideError(input) {
     const errorSpan = input.parentElement.querySelector('.form-input-error');
     errorSpan.style.display = 'none'; 
 }



