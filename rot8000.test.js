var r = require('./rot8000')

var rotator;

beforeAll(() => {
    rotator = new r.rot8000();
  });


test('simple test for set up', () => {
    expect(rotator.rotate("A")).toBe("籊");
});

test('reversability of all BMP codepoints', () => {
    for (var i = 0; i < r.rot8000.BMP_SIZE; i++) {
        var out = rotator.rotate(rotator.rotate(String.fromCharCode(i)));
        expect(out.charCodeAt() == i).toBe(true);
    }
});