namespace PrisonersDilemma
{
    public static class Types
    {
        public enum Strategy
        {
            TFT,   // Tit-for-Tat
            CU,    // Cooperate Unconditionally
            DU     // Defect Unconditionally
        }

        public enum Move
        {
            Cooperate,   
            Defect  
        }
    }
}