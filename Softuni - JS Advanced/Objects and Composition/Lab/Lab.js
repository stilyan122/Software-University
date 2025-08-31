function cityRecord(name, population, treasury) {
    var city = {
        name: name,
        population: population,
        treasury: treasury
    };

    return city;
}

function townPopulation(input) {
    let towns = {};

    for (let i = 0; i < input.length; i++) {
        const kvp = input[i].split(' <-> ');
        const name = kvp[0];
        const population = (Number)(kvp[1]);

        if(towns[name] === undefined){
            towns[name] = population;
        } else{
            towns[name] += population;
        }
    }

    for (const [key, value] of Object.entries(towns)) {
        console.log(`${key} : ${value}`);
      }
}

function cityTaxes(name, population, treasury) {
    var city = {
        name: name,
        population: population,
        treasury: treasury,
        taxRate: 10,
        collectTaxes: function() {
            this.treasury += this.population * this.taxRate
        },
        applyGrowth: function(percent) {
            this.population += this.population * (percent / 100.0)
        },
        applyRecession: function(percent) {
            this.treasury -= this.treasury * (percent / 100.0)
        }
    };

    return city;
}

function objectFactory(library, orders) {
    let output = [];

   for (const order of orders) {
    let template = order["template"];
    let object = template;
    for (const part of order["parts"]) {
        object[part] = library[part];
    }
    output.push(object);
   }

    return output;
}

function assemblyLine() {
    let decoratorFunctions = 
    {
        hasClima: function(object) {
            object.temp = 21;
            object.tempSettings = 21;
            object.adjustTemp = function() {
                if (this.temp < this.tempSettings) {
                    this.temp += 1;
                } else if (this.temp > this.tempSettings) {
                    this.temp -= 1;
                }
            }
        },
        hasAudio: function(object) {
            object.currentTrack = { name: null, artist: null };
            object.nowPlaying = function() {
                if (object.currentTrack !== null) {
                    console.log(`Now playing '${this.currentTrack.name}' by ${this.currentTrack.artist}`);
                }
            }
        },
        hasParktronic: function(object) {
            object.checkDistance = function (distance) {
                if (distance < 0.1) {
                    console.log("Beep! Beep! Beep!");
                } else if (distance >= 0.1 && distance < 0.25) {
                    console.log("Beep! Beep!");
                } else if (distance >= 0.25 && distance < 0.5) {
                    console.log("Beep!");
                } else {
                    console.log("");
                }
            }
        }
    };

    return decoratorFunctions;
}

function fromJSONToHTMLTable(input) {
    const data = JSON.parse(input);

    const escapeHTML = (text) => {
        return text
            .trim()
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;");
    };

    const cleanedData = data.map((row) => {
        const cleanedRow = {};
        for (const [key, value] of Object.entries(row)) {
            const trimmedKey = key.trim();
            const trimmedValue = typeof value === "string" ? escapeHTML(value) : value;
            cleanedRow[trimmedKey] = trimmedValue;
        }
        return cleanedRow;
    });

    let html = "<table>\n";

    const headers = Object.keys(cleanedData[0]);

    html += "  <tr>";

    headers.forEach((header) => {
        html += `<th>${escapeHTML(header)}</th>`;
    });

    html += "</tr>\n";

    clea.forEach((row) => {
        html += "  <tr>";

        headers.forEach((key) => {
            const value = row[key];
            html += `<td>${typeof value === "string" ? escapeHTML(value) : value}</td>`;
        });

        html += "</tr>\n";
    });

    html += "</table>";

    return html;
}