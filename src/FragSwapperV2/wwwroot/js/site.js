$(document).ready(function () {

    // Force the check box to be checked. Use the following attribute in your ViewModel:
    // [Range(typeof (bool), "true", "true", ErrorMessage = "You must check me!")]
    // This script will add the validator to the checkboxes with a Range in the attributes.
    var defaultRangeValidator = $.validator.methods.range;
    $.validator.methods.range = function (value, element, param) {
        if (element.type === 'checkbox') {
            // if it's a checkbox return true if it is checked
            return element.checked;
        } else {
            // otherwise run the default validation function
            return defaultRangeValidator();
        }
    }

});
