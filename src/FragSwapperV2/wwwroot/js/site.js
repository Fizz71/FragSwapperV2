$(document).ready(function () {

    if ($.validator != null) { // Only run this code if the page uses validation.
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
    }

    // To use the site's image popup make your IMG tag like this:
    // <img data-toggle="modal" data-target="#imgModal" ...>
    // This code will look for the SRC of the image tag and push it in as the popped up
    // modal dialog.  It will also look for a _thumb on the end of the image name and 
    // show the version of the file without _thumb on it.
    $('#imgModal').on('show.bs.modal', function (event) {
        $(this).find('.img-responsive').attr("src", $(event.relatedTarget).attr("src").replace("_thumb.", "."));
        $(this).css('display', 'block');
        var $dialog = $(this).find(".modal-dialog");
        var offset = ($(window).height() - $dialog.height()) / 2;
        $dialog.css("margin-top", offset);
    });

});
