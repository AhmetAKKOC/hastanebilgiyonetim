using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

public class PatientController : Controller
{
    private readonly HospitalDbContext _context;

    public PatientController(HospitalDbContext context)
    {
        _context = context;
    }

    // Hasta listesinin görüntülendiği ana sayfa (Index).
    public ActionResult Index()
    {
        // Veritabanından tüm hastaların listesini alır.
        var patients = _context.Patients.ToList();

        // Hastaların listesini Index.cshtml sayfasına gönderir.
        return View(patients);
    }

    [HttpPost]
    public IActionResult Kaydet(Patient patient)
    {
        // Model doğrulama hatası varsa, aynı sayfaya geri dönülebilir veya uygun bir işlem yapılabilir.
        if (!ModelState.IsValid)
        {
            return View("Index", patient);
        }

        // Hasta bilgilerini veritabanına kaydetme işlemleri burada yapılır.
        // Örneğin:
        _context.Patients.Add(patient);
        _context.SaveChanges();

        // Başarılı kayıt sonrasında Privacy sayfasına yönlendirme yapılır.
        return RedirectToAction("Privacy");
    }
}
