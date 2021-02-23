using Models;

namespace lib.Interfaces
{
    /// <summary>Interface modelo da classe de lógica de negócios (BLL) </summary>
    public interface IBllInterface<T> where T : class
    {
        void bll_vld(CurriculumModel adt);
        bool bll_criaCurriculum(CurriculumModel adt);
        string bll_retornaHTMLCurricullum(CurriculumModel adt);
    }
}
