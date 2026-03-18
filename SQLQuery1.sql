Select top(4) * from Chamadas
select top(4) * from ChamadaItems

select top (15) * from Mensalidades
UPDATE dbo.Mensalidades -- Verifique se o nome da sua tabela é 'Financeiro' ou 'Mensalidades'
SET 
    PagamentoStatus = 0,             -- 0 para Pago
    ValorPago = 500.00,      -- Valor integral
    DataPagamento = GETDATE() -- Registra que o pagamento foi hoje (02/03/2026)
WHERE AlunoId = 'DEB2ED18-FBFA-434B-B678-EBA6FAF3D83D'
  AND PagamentoStatus = 2;

  select top(4) * from Despesas