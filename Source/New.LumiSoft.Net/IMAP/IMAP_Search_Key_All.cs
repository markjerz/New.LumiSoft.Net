namespace LumiSoft.Net.IMAP {
    using System;
    using System.Collections.Generic;

    using LumiSoft.Net.IMAP.Client;

    public class IMAP_Search_Key_All : IMAP_Search_Key {
        #region static method Parse

        /// <summary>
        ///     Returns parsed IMAP SEARCH <b>ANSWERED</b> key.
        /// </summary>
        /// <param name="r">String reader.</param>
        /// <returns>Returns parsed IMAP SEARCH <b>ANSWERED</b> key.</returns>
        /// <exception cref="ArgumentNullException">Is raised when <b>r</b> is null reference.</exception>
        /// <exception cref="ParseException">Is raised when parsing fails.</exception>
        internal static IMAP_Search_Key_All Parse(StringReader r) {
            if (r == null) {
                throw new ArgumentNullException("r");
            }

            string word = r.ReadWord();
            if (!string.Equals(word, "ALL", StringComparison.InvariantCultureIgnoreCase)) {
                throw new ParseException("Parse error: Not a SEARCH 'ALL' key.");
            }

            return new IMAP_Search_Key_All();
        }

        #endregion

        #region override method ToString

        /// <summary>
        ///     Returns this as string.
        /// </summary>
        /// <returns>Returns this as string.</returns>
        public override string ToString() {
            return "ALL";
        }

        #endregion

        #region internal override method ToCmdParts

        /// <summary>
        ///     Stores IMAP search-key command parts to the specified array.
        /// </summary>
        /// <param name="list">Array where to store command parts.</param>
        /// <exception cref="ArgumentNullException">Is raised when <b>list</b> is null reference.</exception>
        internal override void ToCmdParts(List<IMAP_Client_CmdPart> list) {
            if (list == null) {
                throw new ArgumentNullException("list");
            }

            list.Add(new IMAP_Client_CmdPart(IMAP_Client_CmdPart_Type.Constant, this.ToString()));
        }

        #endregion
    }
}