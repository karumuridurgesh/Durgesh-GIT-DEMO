

//Filter Change
//#region

function GetFilterDetails(selectedValue) {
  //  //
    PageMethods.GetFilterDetails(selectedValue, OnDetailsSuccess, OnDetailsFailure);
}

function OnDetailsSuccess(result) {
    ////
    FilterDetails = result;
    AfterGettingFilterDetails();
}
function OnDetailsFailure(error) {
   // //
    FilterDetails = "";
}

//#endregion


//Get Filter Values
//#region
function GetFilterValues(selectedValue) {
   // //
    PageMethods.GetFilterValues(selectedValue, OnValuesSuccess, OnValuesFailure);
}
function OnValuesSuccess(result) {
   // //
    FilterValues = result;
    AfterGettingFilterValues();
}
function OnValuesFailure(error) {
  //  //
    FilterValues = "";
}
//#endregion



//Bind Dropdown Values
//#region
function BindDropDownValues(list, JsonValues) {

    list.options.length = 0; //--Normal Remove


    var newOption = document.createElement('option');
    
    var optionText = '';
    var optionValue = '';
    optionText = '--Select--';
    optionValue = 'Select';
    newOption.text = optionText;
    newOption.value = optionValue
    try {
        list.add(newOption, null); // standards compliant; doesn't work in IE
    }
    catch (ex) {
        list.add(newOption); // IE only
    }
        
    for (var i = 0; i < JsonValues.length; i++) {
      
        //alert(listID+','+optionText+','+optionValue, +','+Count);
        newOption = document.createElement('option');
        newOption.text = JsonValues[i].DisplayValue;
        newOption.value = JsonValues[i].StoredValue;

        try {
            list.add(newOption, null); // standards compliant; doesn't work in IE
        }
        catch (ex) {
            list.add(newOption); // IE only
        }
    }
}

/*Validate LOV Textbox Value*/

function ValidateFilterLOVValue(sFieldName, sFieldValue) {
    PageMethods.ValidateFilterLOVValue(sFieldName, sFieldValue, OnValidationSuccess, OnValidationFailure);
}

function OnValidationSuccess(result) {
    LOVValidation = result;
    AfterLOVValidation();
}
function OnValidationFailure(error) {
    LOVValidation = "Y";
}