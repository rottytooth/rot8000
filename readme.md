# rot8000

**rot8000** solves the burning question of the day: how to de-spoilerize text containing non-Western characters, in a universal way. Rot13, which rotates any text 13 characters through the alphabet, was great for Usenet days, so long as you only use the English alphabet. This is rot13 for the Unicode generation.

Rot8000 only works in the Basic Multilingual Plane, which covers languages in use today, including the commonly used CJK characters. If you want to write spoilers in Linear B, you might need another system. It rotates by 0x8000 or half the BMP (actually a bit less than 8000, as it leaves alone whitespace and surrogates). For the most part, it leaves emoji alone (as most live outside of BMP).

The C# version was created when rot13 still used a postback; when it went to JS, rot8000 did as well. Both the C# and JavaScript versions are here; if you just want to start rot8000ing stuff, the rot8000.min.js file is all you need.

Rot8000 was created for the pl41nt3xt pavillion of text-based works, curated by A Bill Miller, for The Wrong (online) digital art biennale.

Discussions:
* [Hacker News](https://news.ycombinator.com/item?id=28615855) (9/2021) 
* [BoingBoing](https://boingboing.net/2021/09/22/the-rot8000-cipher-for-when-rot13-just-isnt-enough-letters.html) (9/2021)
* [Hacker News](https://news.ycombinator.com/item?id=18495518) (11/2018)

Tests in rot8000.test.js ensure reversability of BMP codepoints. **Jest** is needed to run tests. The JS version relies on the C# component to define whitespace, surrogates, etc, which appear in the valid-code-point-transitions.json.

See it in action: [rot8000.com](http://rot8000.com )
