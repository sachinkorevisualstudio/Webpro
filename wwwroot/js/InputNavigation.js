$(document).ready(function () {
    // Handle keydown event for all input elements (text, number, select, textarea, button, etc.)
    $(':input, button').on('keydown', function (e) {
        var $inputs = $(':input, button'); // All form elements, including readonly inputs and buttons
        var index = $inputs.index(this); // Current element index

        // Enter key (key code 13) behaves like Tab
        if (e.keyCode === 13) {
            e.preventDefault(); // Prevent form submission on Enter key
            focusNextInput($inputs, index); // Move to next input
        }

        // Down Arrow key (key code 40)
        if (e.keyCode === 40) {
            e.preventDefault(); // Prevent default action
            focusNextInput($inputs, index); // Move to next input
        }

        // Up Arrow key (key code 38)
        if (e.keyCode === 38) {
            e.preventDefault(); // Prevent default action
            focusPreviousInput($inputs, index); // Move to previous input
        }

        // For buttons, Enter and Space should trigger click
        if ($(this).is('button')) {
            if (e.keyCode === 13 || e.keyCode === 32) { // Enter (13) or Spacebar (32)
                e.preventDefault(); // Prevent default form behavior
                $(this).trigger('click'); // Trigger button click event
            }
        }
    });

    // Add focus event to highlight the active input with black background and white text
    $(':input').on('focus', function () {
        $(this).addClass('active-input'); // Add active-input class
    });

    // Remove background color and text color when the input loses focus
    $(':input').on('blur', function () {
        $(this).removeClass('active-input'); // Remove active-input class
    });

    // Custom function to focus next input
    function focusNextInput($inputs, index) {
        for (let i = index + 1; i < $inputs.length; i++) {
            if ($inputs.eq(i).is(':visible') && !$inputs.eq(i).prop('disabled')) {
                $inputs.eq(i).focus(); // Focus next input
                return; // Exit after focusing
            }
        }
        $inputs.eq(0).focus(); // If last input, loop back to the first input
    }

    // Custom function to focus previous input
    function focusPreviousInput($inputs, index) {
        for (let i = index - 1; i >= 0; i--) {
            if ($inputs.eq(i).is(':visible') && !$inputs.eq(i).prop('disabled')) {
                $inputs.eq(i).focus(); // Focus previous input
                return; // Exit after focusing
            }
        }
        $inputs.eq($inputs.length - 1).focus(); // If first input, loop back to the last input
    }

    // Add style rules dynamically
    $('<style>')
        .prop('type', 'text/css')
        .html(`
            /* Style for active input field */
            .active-input {
                background-color: black !important; /* Black background */
                color: white !important; /* White text */
                border: 2px solid darkorange !important; /* Dark orange border */
            }
            /* Ensure default styles for inputs */
            input, select, textarea {
                color: black !important; /* Default text color */
            }
        `)
        .appendTo('head');
});
