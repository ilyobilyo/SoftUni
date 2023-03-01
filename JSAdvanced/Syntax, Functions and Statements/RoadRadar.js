function slove(speed, area){
    let status = '';
    let diff = 0;
    let limitSpeed = 0;

    switch(area){
        case 'motorway':{
            limitSpeed = 130;
            break;
        }
        case 'interstate':{
            limitSpeed = 90;
            break;
        }
        case 'city':{
            limitSpeed = 50;
            break;
        }
        case 'residential':{
            limitSpeed = 20;
            break;
        }
    }

    if(speed <= limitSpeed){
        console.log(`Driving ${speed} km/h in a ${limitSpeed} zone`);
    }else{
        diff = speed - limitSpeed;

        if(diff <= 20){
            status = 'speeding';
        }else if (diff <= 40){
            status = 'excessive speeding';
        }else{
            status = 'reckless driving';
        }

        console.log(`The speed is ${diff} km/h faster than the allowed speed of ${limitSpeed} - ${status}`);
    }
}

slove(40, 'city');
slove(21, 'residential');
slove(120, 'interstate');
slove(200, 'motorway');
