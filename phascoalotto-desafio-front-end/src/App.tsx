import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { format } from 'date-fns';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Button from '@material-ui/core/Button';
import VisibilityIcon from '@material-ui/icons/Visibility';

import SimpleDialog from './components/Dialog.component';
import {Debt, DebtInstallment } from './interfaces/Debt';

const useStyles = makeStyles({
  container: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
    flexDirection: 'column',
    boxShadow: '0px 0px 0px 0px rgba(0,0,0,0.2)'
  },
  title: {

  },
  table: {
    minWidth: 650,
    maxWidth: 1024,
    margin: '20px',
  },
});

const App = () => {
  const [open, setOpen] = useState(false);
  const [debts, setDebts] = useState<Debt[]>([]);
  const [selectedInstallment, setSelectedInstallment] = useState<DebtInstallment[]>([]);
  const classes = useStyles();

  const handleClickOpenDialog = (installments: DebtInstallment[]) => {
    setOpen(true);
    setSelectedInstallment(installments);
  };

  const handleCloseDialog = () => {
    setOpen(false);
  };

  useEffect(() => {
    axios
      .get('http://localhost:3500/api/Debt')
      .then(response => {
        const debts: Debt[] = response.data;
        setDebts(debts)
      })
      .catch(error => {
        console.log(`Erro ao consultar API. ${error.message}`);
      });
  }, [])

  return (
    <TableContainer className={classes.container} component={Paper}>
      <h1>Dívidas</h1>
      <Table className={classes.table} size="small" aria-label="a dense table">
        <TableHead>
          <TableRow>
            <TableCell>Vencimento</TableCell>
            <TableCell>Qtd. Parcelas</TableCell>
            <TableCell>Valor Original</TableCell>
            <TableCell>Dias Atraso</TableCell>
            <TableCell>Valor Juros</TableCell>
            <TableCell>Valor Final</TableCell>
            <TableCell>Telefone Orientação</TableCell>
            <TableCell>Ações</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {debts.map((debt) => (
            <TableRow key={debt.Id}>
              <TableCell component="th" scope="row">
                {format(
                  new Date(debt.DueDate),
                  "dd/MM/yyyy"
                )}
              </TableCell>
              <TableCell>{debt.InstallmentsCount}</TableCell>
              <TableCell>{`R$ ${debt.OriginalValue}`}</TableCell>
              <TableCell>{debt.LateDays}</TableCell>
              <TableCell>{`R$ ${debt.InterestValue}`}</TableCell>
              <TableCell>{`R$ ${debt.FinalValue}`}</TableCell>
              <TableCell>{debt.OrientationPhone}</TableCell>
              <TableCell>
              <Button
                size="small"
                color="primary"
                onClick={() => {
                  handleClickOpenDialog(debt.Installments);
                }}
                startIcon={<VisibilityIcon />}
              >
              Parcelas
              </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
      <SimpleDialog installments={selectedInstallment} open={open} onClose={handleCloseDialog} />
    </TableContainer>
  );
}

export default App;
