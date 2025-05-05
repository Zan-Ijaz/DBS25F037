export const getMode = () => localStorage.getItem('mode') || 'Buying';
export const setMode = mode => localStorage.setItem('mode', mode);
export const toggleMode = () => {
  const next = getMode() === 'Selling' ? 'Buying' : 'Selling';
  setMode(next);
  return next;
};
