function attachEvents() {
    const button = document.getElementById('submit');
    const forecast = document.getElementById('forecast');
    function error(element){
        element.style.display='block';
        element.textContent='Error';
    }
    button.addEventListener('click',function(){
       const locationName = document.getElementById('location').value;
       const URL = "http://localhost:3030/jsonstore/forecaster/locations";
       fetch(URL)
       .then((res)=>{
        res.json()
        .then((json)=>{
            for (const object of json) {
                if(object.name===locationName){
                    const code = object.code;
                    const conditionURL = 'http://localhost:3030/jsonstore/forecaster/today/'+code;
                    const dayforecastURL = 'http://localhost:3030/jsonstore/forecaster/upcoming/'+code;
                    const container = document.createElement('div');
                    container.classList.add('forecasts');

                    fetch(conditionURL)
                    .then((res)=>{
                        res.json()
                        .then((json)=>{
                            const current = document.getElementById('current');
                            const symbol = document.createElement('span');
                                symbol.classList.add('condition');
                                symbol.classList.add('symbol');
                                switch (json.forecast.condition) {
                                 case 'Sunny':
                                     symbol.innerHTML = '&#x2600;';
                                 break;
                                 case 'Partly sunny':
                                     symbol.innerHTML= '&#x26C5;';
                                 break;
                                 case 'Overcast':
                                     symbol.innerHTML= '&#x2601;';
                                 break;
                                 case 'Rain':
                                     symbol.innerHTML= '&#x2614;';
                                 break;
                                 case 'Rain':
                                     symbol.innerHTML= '&#x2614;';
                                 break;
                                }
                                const spanConditions = document.createElement('span');
                                spanConditions.classList.add('condition');
                                const spanCity = document.createElement('span');
                                spanCity.classList.add('forecast-data');
                                spanCity.textContent=json.name;
                                spanConditions.appendChild(spanCity);
                                const spanDegrees = document.createElement('span');
                                spanDegrees.classList.add('forecast-data');
                                spanDegrees.innerHTML=json.forecast.low+'&#176;'+'/'+json.forecast.high+'&#176;';
                                spanConditions.appendChild(spanDegrees);
                                const spanCondition = document.createElement('span');
                                spanCondition.classList.add('forecast-data');
                                spanCondition.textContent=json.forecast.condition;
                                spanConditions.appendChild(spanCondition);
                                forecast.style.display='block';
                                container.appendChild(symbol);
                                container.appendChild(spanConditions);
                                current.appendChild(container);
                        })
                        .catch((res)=>{
                            error(forecast);
                        });
                    })
                    .catch(()=>{
                        error(forecast);
                       });

                    fetch(dayforecastURL)
                    .then((res)=>{
                        res.json()
                        .then((json)=>{
                            const upcoming = document.getElementById('upcoming');
                            const weatherForecastInfo = document.createElement('div');
                            weatherForecastInfo.classList.add('forecast-info');
                            for (const weather of json.forecast) {
                            const weatherCondition = weather.condition;
                            const weatherHighTemp = weather.high;
                            const weatherLowTemp = weather.low;
                            const weatherSpan = document.createElement('span');
                            weatherSpan.classList.add('upcoming');
                            const weatherSymbol = document.createElement('span');
                            weatherSymbol.classList.add('symbol');
                            switch (weatherCondition) {
                                case 'Sunny':
                                    weatherSymbol.innerHTML = '&#x2600;';
                                 break;
                                 case 'Partly sunny':
                                    weatherSymbol.innerHTML= '&#x26C5;';
                                 break;
                                 case 'Overcast':
                                    weatherSymbol.innerHTML= '&#x2601;';
                                 break;
                                 case 'Rain':
                                    weatherSymbol.innerHTML= '&#x2614;';
                                 break;
                                 case 'Rain':
                                    weatherSymbol.innerHTML= '&#x2614;';
                                 break;
                            }
                            weatherSpan.appendChild(weatherSymbol);
                            const weatherSpanDegrees = document.createElement('span');
                            weatherSpanDegrees.classList.add('forecast-data');
                            weatherSpanDegrees.innerHTML=weatherLowTemp+'&#176;'+'/'+weatherHighTemp+'&#176;';
                            weatherSpan.appendChild(weatherSpanDegrees);
                            const weatherSpanCondition = document.createElement('span');
                            weatherSpanCondition.classList.add('forecast-data');
                            weatherSpanCondition.textContent=weatherCondition;
                            weatherSpan.appendChild(weatherSpanCondition);
                            weatherForecastInfo.appendChild(weatherSpan);
                           }
                           upcoming.appendChild(weatherForecastInfo);
                        })
                        .catch(()=>{
                            error(forecast);
                           });
                    })
                    .catch(()=>{
                        error(forecast);
                       });

                    forecast.appendChild(container);
                    break;
                }
            }
        })
        .catch(()=>{
            error(forecast);
           });
       })
       .catch(()=>{
        error(forecast);
       });
    });
}
attachEvents();