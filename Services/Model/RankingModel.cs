using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public record class RankingModel
    {
        public Guid Id { get; set; }
        public Guid Turmaid { get; set; }
        public Guid Alunoid { get; set; }
        public int Pontos { get; set; }
    }
}
