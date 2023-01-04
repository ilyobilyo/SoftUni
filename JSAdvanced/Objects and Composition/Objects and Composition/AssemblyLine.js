function createAssemblyLine(){
    return {
        hasClima(myCar){
            myCar.temp = 21;
            myCar.tempSettings = 21;
            myCar.adjustTemp = function adjustTemp(){
                if(myCar.temp < myCar.tempSettings){
                    myCar.temp++;
                }else if(myCar.temp > myCar.tempSettings){
                    myCar.temp--;
                }
                return;
            };
        },
        hasAudio(myCar){
            myCar.currentTrack = {
                name: null,
                artist: null,
            };
            myCar.nowPlaying = function nowPlaying(){
                if(this.currentTrack === null){
                    return;
                }
                console.log(`Now playing '${this.currentTrack.name}' by ${this.currentTrack.artist}`);
            }
        },
        hasParktronic(myCar){
            myCar.checkDistance = function checkDistance(distance){
                if(distance < 0.1){
                    console.log("Beep! Beep! Beep!");
                }else if(distance < 0.25){
                    console.log("Beep! Beep!");
                }else if(distance < 0.5){
                    console.log("Beep!");
                }else{
                    console.log('');
                }
            }
        }
    }
}

const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();


assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);

console.log(myCar);