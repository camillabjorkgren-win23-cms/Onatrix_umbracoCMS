function handleContactFormSubmit(event) {
    event.preventDefault()

    fetch('https://api.domain.com/contactform')
    .then(() => {

    })
    .then(() => {

    }).catch(error => {

    })
} 

// function handleContactFormSubmit(event) {
//     event.preventDefault(); // Förhindrar formuläret att skickas

//     // Hämta form inputs
//     const name = document.getElementById('name');
//     const email = document.getElementById('email');
//     const message = document.getElementById('message');
    
//     let isValid = true; // Valideringsflagga
    
//     // Validera namn
//     if (name.value.trim() === '') {
//         showError(name, 'You must enter your name');
//         isValid = false;
//     } else {
//         hideError(name);
//     }

//     // Validera e-post
//     if (!email.validity.valid) {
//         showError(email, 'You must enter a valid email');
//         isValid = false;
//     } else {
//         hideError(email);
//     }

//     // Validera fråga (message)
//     if (message.value.trim() === '') {
//         showError(message, 'You must enter a question');
//         isValid = false;
//     } else {
//         hideError(message);
//     }

//     // Om alla fält är giltiga, skicka formuläret (eller gör något annat)
//     if (isValid) {
//         // Formuläret är giltigt, här kan du hantera formulärinlämningen
//         console.log('Form is valid, submit the form');
//         // t.ex. event.target.submit();
//     }
// }

// // Visar felmeddelanden
// function showError(input, message) {
//     const errorSpan = input.parentElement.querySelector('.form-input-error');
//     errorSpan.textContent = message;
//     errorSpan.style.display = 'block'; // Visa felmeddelandet
// }

// // Dölj felmeddelanden
// function hideError(input) {
//     const errorSpan = input.parentElement.querySelector('.form-input-error');
//     errorSpan.style.display = 'none'; // Dölj felmeddelandet
// }


document.getElementById("email").setAttribute("pattern", "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
