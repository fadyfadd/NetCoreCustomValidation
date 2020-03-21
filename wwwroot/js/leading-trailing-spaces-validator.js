
$.validator.addMethod('leadingtrailingspaces', function (value, element, params) {
  
    if (value == null || value.trim() === value) {
        return true;
    }
    else
        return false; 
});



$.validator.unobtrusive.adapters.add('leadingtrailingspaces', [], function (options) {   

    options.rules['leadingtrailingspaces'] = [];
    options.messages['leadingtrailingspaces'] = options.message;
});
