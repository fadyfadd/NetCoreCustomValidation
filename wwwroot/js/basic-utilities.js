

function convertDateFormat(strSourceDate, strSourceMask, strTargetMask) {

    try {
        let m = moment(strSourceDate, strSourceMask , true);

        if (m.isValid()) {
            let formattedDate = m.format(strTargetMask);
            return formattedDate;
        }
        else
            return null;
    }
    catch
    {
        return null;
    }
}

function parseMomentFromString(strValue, mask) {
    try {
        // if (mask == null)
        //     mask = "YYYY-MM-DDTHH:mm:ss";

        var m = moment(strValue, mask , true);

        if (!m.isValid()) {
            return null;
        }

        return m;
    }
    catch (e) {
        return null;
    }
}

function encodeJs(value) {
    var res = value.
        replace(/\\/g, "\\\\").
        replace(/"/g, "\\\"").
        replace(/'/g, "\\''").
        replace(/`/g, "\\`");
    return res;
}

function encodeHtml(value) {
    var res = value.
        replace(/&/g, "&amp;").
        replace(/</g, "&lt;").
        replace(/>/g, "&gt;").
        replace(/'/g, "&apos;").
        replace(/"/g, "&quot;");
    return res;
}

function parseSingleLine(line) {
    
    var x = [];
    var columns = line.split('\t');

    for (var i = 0 ;i<=columns.length -1;i++) {
        x.push(columns[i]);
    }

    return x; 

}

function parseSpreadSheet(content) {
    
    var y = [];
    var lines = value.split('\n');
    
    for (var i = 0 ;  i <= lines.length -1;i++) {
        var rawLine = lines[i];
        var parsedLine = parseSingleLine(rawLine);
        y.push(parsedLine);        
    }

    return y;
}