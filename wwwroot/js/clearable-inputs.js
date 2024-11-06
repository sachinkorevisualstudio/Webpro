$(document).ready(function () {
    // Dynamically inject the clear button CSS into the page
    var clearableCss = `
        .clearable {
            position: relative;
        }
        .clearable input {
            padding-right: 25px; /* Add space for the 'X' button */
        }
        .clearable .clear-button {
            position: absolute;
            right: 5px;
            top: 50%;
            transform: translateY(-50%);
            width: 18px;
            height: 18px;
            background-color: #ccc;
            border-radius: 50%;
            text-align: center;
            font-size: 12px;
            line-height: 16px;
            cursor: pointer;
            display: none; /* Initially hidden */
        }
    `;
    // Add the CSS to the head of the document
    $('<style>').prop('type', 'text/css').html(clearableCss).appendTo('head');

    // Add the clear button dynamically to every input[type="text"] and input[type="number"]
    $('input[type="text"], input[type="number"]').each(function () {
        var $this = $(this);
        // Only add clear button if not already added
        if (!$this.parent().hasClass('clearable')) {
            // Wrap the input in a div with class 'clearable'
            $this.wrap('<div class="clearable"></div>');
            // Append the clear button
            $this.after('<span class="clear-button">x</span>');
        }
    });

    // Show or hide the clear button based on input value
    $('input[type="text"], input[type="number"]').on('input', function () {
        var $clearBtn = $(this).siblings('.clear-button');
        if ($(this).val()) {
            $clearBtn.show();  // Show the clear button when there's input
        } else {
            $clearBtn.hide();  // Hide when empty
        }
    });

    // Handle click on the clear button
    $(document).on('click', '.clear-button', function () {
        var $input = $(this).siblings('input');

        // Clear text input fields (set to empty string)
        if ($input.attr('type') === 'text') {
            $input.val('').focus();
        }

        // Set number input fields to 0
        if ($input.attr('type') === 'number') {
            $input.val(0).focus();
        }

        // Hide the clear button after clearing
        $(this).hide();
    });
});
