function collapseNode(nodeKey , context) {
    
var clickedRow = $("tr[context='" + context + "'][key='" + nodeKey + "']");
var handle =  $("tr[context='" + context + "'][key='" + nodeKey + "'] i[handle]");

handle.removeClass("fa-caret-down");
handle.addClass("fa-caret-right");
clickedRow.attr("isExpanded" , 0);

var childRows = $("tr[context='" + context + "'][parentkey='" + nodeKey + "']");
var childrenHandles = $("tr[context='" + context + "'][parentkey='" + nodeKey + "'] i[handle]");

childrenHandles.each(function(i,e) {
    $(e).removeClass("fa-caret-down");
    $(e).addClass("fa-caret-right");
});

childRows.each(function(i ,e) {
    
    $(e).css("display" , "none");
    
    var subChildrens = $("tr:visible[context='" + context + "'][parentkey='" + $(e).attr("key") + "']");
    
    subChildrens.each(function(i,e) {
         collapseSubNodes($(e).attr("key") , context);
    });

});

}

function collapseSubNodes(nodeKey , context) {

var currentRow = $("tr[context='" + context + "'][key='" + nodeKey + "']");

var currentHandle =  $("tr[context='" + context + "'][key='" + nodeKey + "'] i[handle]");
currentRow.attr("isExpanded" , 0);

currentHandle.removeClass("fa-caret-right");
currentHandle.removeClass("fa-caret-down");
currentRow.css("display" , "none");

var childRows = $("tr[context='" + context + "'][parentkey='" + nodeKey + "']");

childRows.each(function(i,e) {
     collapseSubNodes($(e).attr("key"),context);
});

}

function expandNode(nodeKey , context) {

var clickedRow = $("tr[context='" + context + "'][key='" + nodeKey + "']");        
var handle =  $("tr[context='" + context + "'][key='" + nodeKey + "'] i[handle]");

handle.removeClass("fa-caret-right");
handle.addClass("fa-caret-down");
clickedRow.attr("isExpanded" , 1);

var childRows = $("tr[context='" + context + "'][parentKey='" + nodeKey + "']");     
var childrenHandles = $("tr[context='" + context + "'][parentkey='" + nodeKey + "'] i[handle]");

childrenHandles.each(function(i,e) {         
    $(e).removeClass("fa-caret-down");
    $(e).addClass("fa-caret-right");
});

childRows.each(function(i ,e) {             
    $(e).css("display" , "table-row");      
    
    var subChildrens = $("tr[context='" + context + "'][parentkey='" + $(e).attr("key") + "']");
    subChildrens.each(function(i,e) {
        //collapseSubNodes($(e).attr("key") , context);
    });
    
});
}

function expandAll(context) {

    $('tr[context=' + context + ']').attr("isexpanded" , "1").css("display" , "table-row");        
    $('tr[context=' + context + '] [handle]').removeClass("fa-caret-right");
    $('tr[context=' + context + '] [handle]').addClass("fa-caret-down");
}

function collapseAll(context) {

    $('tr[context=' + context  + ']:not([parentkey=""])').attr("isexpanded" , 0).css("display" , "none");
    $('tr[context=' + context + '][parentkey=""]').attr("isexpanded" , 0);       
    $('tr[context=' + context + '][parentkey=""] [handle]').removeClass("fa-caret-down").addClass("fa-caret-right");     
    $('tr[context=' + context + ']:not([parentkey=""]) [handle]').removeClass("fa-caret-right");
    $('tr[context=' + context + ']:not([parentkey=""]) [handle]').removeClass("fa-caret-down");
}

function toggleNode(nodeKey , context) {    

var clickedRow = $("tr[context='" + context + "'][key='" + nodeKey + "']");

if (clickedRow.attr("isExpanded") == "0") {
    expandNode(nodeKey , context);            
}
else {
    collapseNode(nodeKey , context);             
}       

}

function mark(query , context) {
$("tr[context=" + context + "]" + query + " td").addClass('hightlight_element');
}
     
function unmark(query , context) {
    $("tr[context=" + context + "]" + query + " td").removeClass('hightlight_element');
}

function showNode(nodekey , context , highlight) {           

    var row = $("tr[key=" + nodekey + "][context=" + context + "]");

    if (highlight)                   
        mark("[key=" + nodekey + "]" , context);
    
    var parentKey = row.attr('parentKey');
    var parentList = [];
    
    while (parentKey != "") {                
        parentList.unshift(parentKey);
        var row = $("tr[key=" + parentKey + "][context=" + context + "]");
        var parentKey = row.attr('parentKey');
    }

    for (i=0;i<=parentList.length-1;i++) { 
        expandNode(parentList[i] ,  context);
    }

}
