# rot8000

**rot8000** solves the burning question of the day: how to de-spoilerize text containing non-Western characters. Rot13, which rotates any text 13 characters through the alphabet, was great for Usenet days, so long as you only use the English alphabet. This is rot13 for the Unicode generation.

Release history:
*  2013: released for the [pl41nt3xt pavillion](http://pl41nt3xt.master-list2000.com/artists/danieltemkin.html ) of the Wrong biennial
*  2013: [ate a lot of shit]( https://www.reddit.com/r/programming/comments/1q5g7m/rot13_for_the_unicode_generation/ ) because it didn't work so good for CJK characters
*  2017: all fixed here ya go!
*  2017: releasing open source so you can see how it works

Rot8000 only works in the Basic Multilingual Plane, it ignores higher characters. It rotates by 0x8000 or half the BMP (actually a bit less than that, as it doesn't transform whitespace, control or surrogate characters). 

See it in action: [rot8000.com](http://rot8000.com )
