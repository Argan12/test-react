import React from 'react';
import { Toaster, toast } from 'react-hot-toast';

function ToastComponent() {
  toast("Hello");
  return (
    <Toaster />
  );
}

export default ToastComponent;