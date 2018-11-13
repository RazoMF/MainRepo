select * 
from user_objects
where months_between(sysdate, last_ddl_time) < 6
order by LAST_DDL_TIME desc;