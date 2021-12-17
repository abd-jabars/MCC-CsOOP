using System;
using System.Collections.Generic;
using System.Text;

namespace MCC_CsOOP
{
    public class Mahasiswa
    {
        public String nameMhs { get; set; }
        public String nimMhs { get; set; }
        public int examValMhs { get; set; }

        public Mahasiswa(string nameMhs, string nimMhs, int examValMhs)
        {
            this.nameMhs = nameMhs;
            this.nimMhs = nimMhs;
            this.examValMhs = examValMhs;
        }

        public Mahasiswa(int examValMhs)
        {
            this.examValMhs = examValMhs;
        }

        public Mahasiswa()
        {
        }
    }
}
