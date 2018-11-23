
function rot8000() 
{
    // these come from the valid-code-point-transitions.json file generated from the c# proj
    // this is done bc: 1) don't trust JS's understanging of surrogate pairs and 2) consistency with original rot8000
    const valid_code_points = 
        JSON.parse('{"33":true,"127":false,"161":true,"5760":false,"5761":true,"8192":false,"8203":true,"8232":false,"8234":true,"8239":false,"8240":true,"8287":false,"8288":true,"12288":false,"12289":true,"55296":false,"57344":true}');

    const BMP_SIZE = 0x10000;

    this.rotlist = {}; // the mapping of char to rotated char


    hiddenblocks = [];
    var startblock = 0;

    for (var key in valid_code_points) {
        if (valid_code_points.hasOwnProperty(key)) {
            if (valid_code_points[key] == true)
                hiddenblocks.push({ start: startblock, end: parseInt(key) - 1 });
            else
                startblock = parseInt(key);
        }
    }

    var validintlist = []; // list of all valid chars

    var currvalid = false;

    for (var i = 0; i < BMP_SIZE; i++) {
        if (valid_code_points[i] !== undefined) {
            currvalid = valid_code_points[i]
        }
        if (currvalid) validintlist.push(i);
    }
    var rotatenum = Object.keys(validintlist).length / 2;

    // go through every valid char and find its match
    for (var i = 0; i < validintlist.length; i++) {
        this.rotlist[String.fromCharCode(validintlist[i])] = 
            String.fromCharCode(validintlist[(i + rotatenum) % (rotatenum * 2)]);
    }

    this.rotate = function(convstring)
    {
        var outstring = "";

        for (var count = 0; count < convstring.length; count++)
        {
            // if it is not in the mappings list, just add it directly (no rotation)
            if (this.rotlist[convstring[count]] === undefined)
            {
                outstring += convstring[count];
                continue;
            }

            // otherwise, rotate it and add it to the string
            outstring += this.rotlist[convstring[count]];
        }

        return outstring;
    }
}
module.exports = {rot8000};
