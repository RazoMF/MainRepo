/*����� ��� ��������� ��������. ������� ���� � ��������.*/
SELECT /*+ FIRST_ROWS(20) */ * ---������������ ������ ��� ������� ������ �����
  FROM bigtab
  WHERE bigtab.id != 10;