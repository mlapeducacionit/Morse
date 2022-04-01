using NUnit.Framework;

namespace Decoder.nUnit
{
    public class Tests
    {
        [Test]
        public void Bits2Morse_HOLAMELI()
        {
            string args = "000000001101101100111000001111110001111110011111100000001110111111110111011100000001100011111100000111111001111110000000110000110111111110111011100000011011100000000000";
            
            Assert.AreEqual(".... --- .-.. .- -- . .-.. ..",Decode.Bits2Morse(args));
        }
        [Test]
        public void Bits2Morse_CAKETEST()
        {
            string args = "000001100101010100100101101001001010010101001101001101101100110101101001011001101011001000000000";

            Assert.AreEqual("- .... . .-. . .. ... -. --- -.-. .- -.- .", Decode.Bits2Morse(args));
        }
        [Test]
        public void Morse2Human_HOLAMELI()
        {
            string args = ".... --- .-.. .- -- . .-.. ..";
            Assert.AreEqual("HOLAMELI",Decode.Morse2Human(args));
        }
        [Test]
        public void Morse2Human_CAKETEST()
        {
            string args = "- .... . .-. . .. ... -. --- -.-. .- -.- .";
            Assert.AreEqual("THEREISNOCAKE", Decode.Morse2Human(args));
        }
        [Test]
        public void Bits2Human_HOLAMELI()
        {
            string args = "000000001101101100111000001111110001111110011111100000001110111111110111011100000001100011111100000111111001111110000000110000110111111110111011100000011011100000000000";

          
            Assert.AreEqual("HOLAMELI", Decode.Morse2Human(Decode.Bits2Morse(args)));
        }
        [Test]
        public void Bits2Human_CAKETEST()
        {
            string args = "000001100101010100100101101001001010010101001101001101101100110101101001011001101011001000000000";
            Assert.AreEqual("THEREISNOCAKE", Decode.Morse2Human(Decode.Bits2Morse(args)));
        }
    }
}