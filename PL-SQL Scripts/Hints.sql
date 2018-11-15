/*����� ��� ��������� ��������. ������� ���� � ��������.*/
SELECT /*+ FIRST_ROWS(20) */ * ---������������ ������ ��� ������� ������ �����
  FROM bigtab
  WHERE bigtab.id != 10;
 
--Join �� ����
select /*+ USE_HASH(t2 t1) */ * 
from bigtab4 t1 
join bigtab t2 on t2.id = t1.id;
  
--��������� ������. ��������� ������� = 1888.
select *
from bigtab4 t1 
where id = 1000;

--�������� ������
create index bigtab4_id_idx on bigtab4(id);

--������ ��������� ������� = 7.
select /*+ Index(t1 bigtab4_id_idx) */ *
from bigtab4 t1 
where id = 1000;

