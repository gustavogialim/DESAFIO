import React from 'react';
import { format } from 'date-fns';
import { makeStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import ListSubheader from '@material-ui/core/ListSubheader';
import ListItemText from '@material-ui/core/ListItemText';
import Dialog from '@material-ui/core/Dialog';

import { DebtInstallment } from '../interfaces/Debt';

const useStyles = makeStyles({
  list: {
    width: '300px',
    padding: 15,
  },
});

export interface SimpleDialogProps {
  open: boolean;
  installments: DebtInstallment[];
  onClose: () => void;
}

export default function SimpleDialog(props: SimpleDialogProps) {
  const classes = useStyles();
  const { open, installments, onClose } = props;

  const handleClose = () => {
    onClose();
  };

  return (
    <Dialog onClose={handleClose} aria-labelledby="dialog-title" open={open}>
      <List
        className={classes.list}
        subheader={
          <ListSubheader component="div" id="nested-list-subheader">
            Detalhes da parcela
          </ListSubheader>
        }
      >
        {installments.map((installment, index) => {
          const dueDate = format(new Date(installment.DueDate), "dd/MM/yyyy");

          return (
            <ListItemText
              key={installment.Id}
              primary={`${index + 1} - R$ ${installment.FinalValue} - Vencimento: ${dueDate}`}
            />
          );
        })}
      </List>
    </Dialog>
  );
}
