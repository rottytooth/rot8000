# rot8000

**rot8000** solves the burning question of the day: how to de-spoilerize text containing non-Western characters, in a universal way. Rot13, which rotates any text 13 characters through the alphabet, was great for Usenet days, so long as you only use the English alphabet. This is rot13 for the Unicode generation.

Rot8000 only works in the Basic Multilingual Plane, which covers languages in use today, including the commonly used CJK characters. If you want to write spoilers in Linear B, you might need another system. It rotates by 0x8000 or half the BMP (actually a bit less than 8000, as it leaves alone whitespace and surrogates). 

For JS, use the rot8000.min.js file.

**Update 11/2018**: Project has been moved to JavaScript. When I began in 2013, rot13.com used a postback, and I followed suit. But after the recent attention on [Hacker News](https://news.ycombinator.com/item?id=18495518), I decided to update to JS, as rot13.com had.

While the JS version might be useful for more people, I'm keeping the C# code for Mastadon/Twitterbots. Also, the codeblocks that don't translate (whitespace, surrogates, etc) are still defined by output from the C# component, even in the JS version, due to JS's weird Unicode handling (those blocks are defined in the valid-code-point-transitions.json file).

Tests in rot8000.test.js ensure reversability of BMP codepoints. **Jest** is needed to run tests.

See it in action: [rot8000.com](http://rot8000.com )
