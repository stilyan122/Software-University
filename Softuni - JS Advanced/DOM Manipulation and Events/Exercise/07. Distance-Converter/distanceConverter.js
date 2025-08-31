function attachEventsListeners() {
    let convertButton = document.getElementById('convert');
    let inputDistance = document.getElementById('inputDistance');

    let inputUnits = document.getElementById('inputUnits');
    let outputUnits = document.getElementById('outputUnits');

    let outputDistanceField = document.getElementById('outputDistance');
    
    convertButton.addEventListener('click', function(){
        let selectedInputUnit = inputUnits.options[inputUnits.selectedIndex].value;
        let inputDistanceValue = Number(inputDistance.value);
        let meters = 0;

        switch(selectedInputUnit){
            case 'km':
                meters = inputDistanceValue * 1000;
                break;
            case 'm':
                meters = inputDistanceValue;
                break;
            case 'cm':
                meters = inputDistanceValue * 0.01;
                break;
            case 'mm':
                meters = inputDistanceValue * 0.001;
                break;
            case 'mi':
                meters = inputDistanceValue * 1609.34;
                break;
            case 'yrd':
                meters = inputDistanceValue * 0.9144;
                break;
            case 'ft':
                meters = inputDistanceValue * 0.3048;
                break;
            case 'in':
                meters = inputDistanceValue * 0.0254;
                break;
        };

        let selectedOutputUnit = outputUnits.options[outputUnits.selectedIndex].value;
        let outputDistance = 0;

        switch(selectedOutputUnit){
            case 'km':
                outputDistance = meters / 1000;
                break;
            case 'm':
                outputDistance = meters;
                break;
            case 'cm':
                outputDistance = meters / 0.01;
                break;
            case 'mm':
                outputDistance = meters / 0.001;
                break;
            case 'mi':
                outputDistance = meters / 1609.34;
                break;
            case 'yrd':
                outputDistance = meters / 0.9144;
                break;
            case 'ft':
                outputDistance = meters / 0.3048;
                break;
            case 'in':
                outputDistance = meters / 0.0254;
                break;
        };

        outputDistanceField.value = outputDistance;
    });
}