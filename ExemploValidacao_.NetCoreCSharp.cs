public class ClienteController : Controller {
    [HttpPost]
    public IActionResult Novo(ClienteViewModel clienteViewModel, string returnUrl)
    {
         var clienteByEmail = _clienteServices.GetByEmail(clienteViewModel.email);
        var clienteByCnpj = _clienteServices.GetByCpf(clienteViewModel.cpf);

        List<string> erros = new List<string>();
        if (clienteByEmail != null)
        {
            erros.Add("Email já cadastrado");
        }

        if (clienteByCnpj != null)
        {
            erros.Add("CPF já cadastrado");
        }
            if (erros.Count > 0)
        {
            foreach (var erro in erros)
            {
                var keyError = erro.Split(" ")[0].ToLower();
                ModelState.AddModelError(keyError, erro);
            }
            return View(clienteViewModel);
        }
            
        _clienteServices.Create(clienteViewModel);

        return Redirect(returnUrl);
    }
}
