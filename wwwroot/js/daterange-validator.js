
$.validator.addMethod('daterange', function (value, element, params) {

    
    if (value == null || value == "") {
        return true;
    }
    else {

        let dte1 = new Date(params[0]);
        let dte2 = new Date(params[1]);
        let currentValue = new Date(value);
       
        if (currentValue >= dte1 && currentValue <= dte2)
            return true;
        else
            return false;
    }       
    
        
});


$.validator.unobtrusive.adapters.add('daterange', ['date1' , 'date2'], function (options) {   
     
    options.rules['daterange'] = [options.params['date1'], options.params['date2']];
    options.messages['daterange'] = options.message;
});
